using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base : MonoBehaviour
{
    [SerializeField] private Scanner _scanner;
    [SerializeField] private Unit _prefabUnit;
    [SerializeField] private List<Unit> _units;

    private Dictionary<StateType, IBaseState> _baseStates;
    private IBaseState _currentState;

    private Queue<Unit> _unitQueue = new Queue<Unit>();
    private Flag _flag;
    private float _numberCoins = 0;

    public float NumberCoins => _numberCoins;

    private void Awake()
    {
        AddUnitsList();

        _flag = GetComponentInChildren<Flag>();
        _baseStates = new Dictionary<StateType, IBaseState>();

        _baseStates.Add(StateType.BildUnits, new CreationUnitsState(this));
        _baseStates.Add(StateType.BuildingBase, new BuildingBase(this));

        _currentState = _baseStates[StateType.BildUnits];
    }

    private void Start()
    {
        StartCoroutine(Work());
    }

    private void OnEnable()
    {
        _flag.UnitHasArrived += BackCreatingUnits;
    }

    private void OnDisable()
    {
        _flag.UnitHasArrived -= BackCreatingUnits;
    }

    private void Update()
    {
        _currentState.Run();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Unit>(out Unit unit) && unit.IsSent == true)
        {
            unit.ChangeStatus();
            _unitQueue.Enqueue(unit);

            _numberCoins++;
        }
    }

    private IEnumerator Work()
    {
        bool IsCoinsFound = true;

        while (IsCoinsFound)
        {
            float coinCheckTimer = 4;
            var checking—oins = new WaitForSeconds(coinCheckTimer);

            Queue<Coin> freeCoins = _scanner.GetCoins();

            int count = Mathf.Min(freeCoins.Count, _unitQueue.Count);

            for (int i = 0; i < count; i++)
            {
                Unit currentUnit = _unitQueue.Peek();
                Coin currentCoin = freeCoins.Peek();

                currentUnit.AssignId(currentCoin.Id);

                if (_flag.IsInstalled == true)
                {
                    _currentState = _baseStates[StateType.BuildingBase];
                }

                if (currentUnit.IsSent == false)
                {
                    currentUnit.MoveToTarget(currentCoin.transform);

                    currentUnit.ChangeStatus();
                    currentCoin.ChangeColor();

                    _unitQueue.Dequeue();
                    freeCoins.Dequeue();
                }
            }

            yield return checking—oins;
        }
    }

    public void AddUnitsList()
    {
        for (int i = 0; i < _units.Count; i++)
        {
            _units[i].SetBaseCoordinate(transform);
            _unitQueue.Enqueue(_units[i]);
        }
    }

    public void AssignUnit(Unit unit)
    {
        _unitQueue.Enqueue(unit);
    }

    public void SubtractCoins(int cost)
    {
        _numberCoins -= cost;
    }

    public bool HasCoins(int cost)
    {
        if (_numberCoins >= cost)
            return true;

        return false;
    }

    public void SendToFlag()
    {
        Unit unit = _unitQueue.Dequeue();
        unit.MoveToTarget(_flag.transform);
    }

    public bool HasFreeUnit()
    {
        if (_unitQueue.Count > 0)
        {
            return true;
        }

        return false;
    }

    public void CreateUnit()
    {
        Unit newUnit = Instantiate(_prefabUnit, transform.position, Quaternion.identity);
        newUnit.SetBaseCoordinate(transform);
        _unitQueue.Enqueue(newUnit);
    }

    private void BackCreatingUnits(Unit unit)
    {
        _currentState = _baseStates[StateType.BildUnits];
    }
}
